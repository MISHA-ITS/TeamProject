import type {IUserRowProps} from "../typs.ts";
import * as React from "react";
import EnvConfig from "../../config/env.ts";
import {Link} from "react-router-dom";

const UserRow : React.FC<IUserRowProps> = ({ user, initials }) => {
    return (
        <>
            <Link to={`/users/${user.id}`}>
                <li className="m-3 p-1 border rounded-lg shadow-lg flex items-center w-full gap-4">
                    {/* Аватар */}
                    <div className="w-16 flex-shrink-0">
                        {user.image ? (
                            <img
                                src={`${EnvConfig.API_URL}images/${user.image}`}
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
                    <div className="w-64 flex-shrink-0 text-blue-500">
                        {user.email}
                    </div>

                    {/* Ролі */}
                    <div className="flex-1 text-gray-600 text-sm">
                        {user.roles ? user.roles.join(", ") : ""}
                    </div>

                    {/* Кнопки */}
                    <div className="flex gap-2">
                        <Link to="/EditUserPage" className="px-3 py-1 bg-green-500 text-white rounded hover:bg-green-700"
                                onClick={() => alert(`Edit user ${user.id}`)}
                        >
                            Редагувати
                        </Link>
                        <Link to="/DelitUserPage" className="px-3 py-1 bg-red-500 text-white rounded hover:bg-red-700"
                                onClick={() => alert(`Delete user ${user.id}`)}
                        >
                            Видалити
                        </Link>
                    </div>
                </li>
            </Link>
        </>
    )
}

export default UserRow;