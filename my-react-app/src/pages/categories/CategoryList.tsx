import { useEffect, useState } from "react";
import axios from "axios";
import type { ICategoryItem } from "../types.ts";
import type { IApiResponse } from "../types.ts";
import EnvConfig from "../../config/env.ts";
import CategoryRow from "./CategoryRow.tsx";

const UsersList = () => {
    const urlGetUsersList = `${EnvConfig.API_URL}api/categories/List`;

    const [users, setUsers] = useState<ICategoryItem[]>([]);

    const initials = (name: string | null) =>
        name ? name.charAt(0).toUpperCase() : "";

    useEffect(() => {
        axios.get<IApiResponse<ICategoryItem[]>>(urlGetUsersList)
            .then(response => {
                console.log("axios result", response.data);
                setUsers(response.data.payLoad);
            })
            .catch(error => {
                console.log("axios error", error);
            });
    }, []);

    return (
        <div className="max-w-4xl mx-auto mt-10">
            <h1 className="text-3xl font-bold text-center mb-6">Зареєстровані категорії</h1>

            {users.length === 0 ? (
                <p className="text-center text-gray-500">Категорії не знайдено</p>
            ) : (
                <ul className="space-y-4">
                    {users.map(category => (
                        <CategoryRow
                            key={category.id}
                            category={category}
                            initials={initials}
                        />
                    ))}
                </ul>
            )}
        </div>
    );
};

export default UsersList;
