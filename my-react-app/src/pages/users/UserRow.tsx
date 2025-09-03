import type {IUserRowProps} from "./typs";

const UserRow = ({ user, urlServer, initials }: IUserRowProps) => {
    return (
        <li className="p-4 border rounded-lg shadow-sm flex items-center w-full gap-4">
            {/* Аватар */}
            <div className="w-16 flex-shrink-0">
                {user.image ? (
                    <img
                        src={`${urlServer}images/${user.image}`}
                        alt={`${user.firstName ?? ""} ${user.lastName ?? ""}`}
                        className="w-12 h-12 rounded-full object-cover"
                    />
                ) : (
                    <div className="w-12 h-12 rounded-full bg-gray-300 flex items-center justify-center text-white font-bold">
                        {initials(user.firstName)}{initials(user.lastName)}
                    </div>
                )}
            </div>

            {/* Ім’я */}
            <div className="w-48 flex-shrink-0 font-semibold">
                {user.firstName ?? ""} {user.lastName ?? ""}
            </div>

            {/* Email */}
            <div className="w-64 flex-shrink-0 text-gray-600">
                {user.email}
            </div>

            {/* Ролі */}
            <div className="flex-1 text-blue-500 text-sm">
                {user.roles ? user.roles.join(", ") : ""}
            </div>

            {/* Кнопки */}
            <div className="flex gap-2">
                <button className="px-3 py-1 bg-green-500 text-white rounded hover:bg-green-600">
                    Редагувати
                </button>
                <button className="px-3 py-1 bg-red-500 text-white rounded hover:bg-red-600">
                    Видалити
                </button>
            </div>
        </li>
    )
}

export default UserRow;