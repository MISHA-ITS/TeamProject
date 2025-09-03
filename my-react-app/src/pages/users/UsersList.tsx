import { useEffect, useState } from "react";
import axios from "axios";
import type { IUserItem } from "./typs";
import type { IApiResponse } from "./typs";
import UserRow from "./UserRow";

const UsersList = () => {
    const urlServer = "http://localhost:5137/";
    const urlGetUsersList = `${urlServer}api/user/List`;

    const [users, setUsers] = useState<IUserItem[]>([]);

    const initials = (name: string | null) =>
        name ? name.charAt(0).toUpperCase() : "";

    useEffect(() => {
        axios.get<IApiResponse<IUserItem[]>>(urlGetUsersList)
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
            <h1 className="text-3xl font-bold text-center mb-6">Users List</h1>

            {users.length === 0 ? (
                <p className="text-center text-gray-500">Користувачів не знайдено</p>
            ) : (
                <ul className="space-y-4">
                    {users.map(user => (
                        <UserRow
                            key={user.id}
                            user={user}
                            urlServer={urlServer}
                            initials={initials}
                        />
                    ))}
                </ul>
            )}
        </div>
    );
};

export default UsersList;
