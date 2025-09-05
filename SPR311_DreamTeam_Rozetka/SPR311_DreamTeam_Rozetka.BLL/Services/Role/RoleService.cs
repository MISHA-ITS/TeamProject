using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;
using SPR311_DreamTeam_Rozetka.BLL.Services.Image;
using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<ServiceResponse> CreateAsync(CreateRoleDTO dto)
        {
            if (!await IsUniqueNameAsync(dto.Name))
            {
                return ServiceResponse.Error($"Роль з іменем {dto.Name} вже існує");
            }

            var entity = _mapper.Map<AppRole>(dto);

            var result = await _roleManager.CreateAsync(entity);
            entity.NormalizedName = dto.Name.ToUpper();

            if (result.Succeeded)
            {
                return ServiceResponse.Success($"Роль {entity.Name} успішно додано", dto);
            }
            return ServiceResponse.Error($"Не вдалося створити роль");
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateRoleDTO dto)
        {
            var entity = _mapper.Map<AppRole>(dto);

            var result = await _roleManager.UpdateAsync(entity);

            if (result.Succeeded)
            {
                return ServiceResponse.Success($"Роль {entity.Name} успішно оновлено", dto);
            }
            return ServiceResponse.Error($"Не вдалося оновити роль");
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Error($"Роль з id {id} не знайдено");
            }

            var result = await _roleManager.DeleteAsync(entity);

            if (result.Succeeded)
            {
                return ServiceResponse.Success($"Роль {entity.Name} успішно видалено");
            }

            return ServiceResponse.Error($"Не вдалося видалити роль");
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _roleManager.Roles
                .ToListAsync();

            var dtos = _mapper.Map<List<RoleDTO>>(entities);

            return ServiceResponse.Success("Ролі отримано", dtos);
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Error($"Роль з id {id} не знайдено");
            }

            var dto = _mapper.Map<RoleDTO>(entity);

            return ServiceResponse.Success($"Роль з id {id} отримано", dto);
        }

        // Додати конкретну роль юзеру
        public async Task<ServiceResponse> AddRoleToUserAsync(AddRoleToUserDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.userId);
            if (user == null)
            {
                return ServiceResponse.Error($"Користувач з id {dto.userId} не знайдено");
            }

            // Перевірити чи роль існує
            if (!await _roleManager.RoleExistsAsync(dto.roleName))
            {
                await _roleManager.CreateAsync(new AppRole { Name = dto.roleName });
            }

            var result = await _userManager.AddToRoleAsync(user, dto.roleName);

            if (result.Succeeded)
            {
                return ServiceResponse.Success($"Роль {dto.roleName} успішно видано користувачу {user.UserName}");
            }

            return ServiceResponse.Error($"Не вдалося видати роль користувачу {user.UserName}");
        }

        // Видалити конкретну роль у юзера
        public async Task<ServiceResponse> RemoveRoleFromUserAsync(DeleteRoleFromUserDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.userId);
            if (user == null)
            {
                return ServiceResponse.Error($"Користувач з id {dto.userId} не знайдено");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, dto.roleName);

            if (result.Succeeded)
            {
                return ServiceResponse.Success($"Роль {dto.roleName} успішно знято з користувача {user.UserName}");
            }
            return ServiceResponse.Error($"Не вдалося зняти роль з користувача {user.UserName}");
        }

        public async Task<bool> IsUniqueNameAsync(string name)
        {
            return !await _roleManager.Roles
                .AnyAsync(c => c.NormalizedName == name.ToUpper());
        }
    }
}
