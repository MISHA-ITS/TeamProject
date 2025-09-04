import React, { useEffect, useState } from "react";
import axios from "axios";
import type { ICategoryItem } from "../typs";
import type { IApiResponse } from "../typs.ts";
import EnvConfig from "../../config/env.ts";

const Sidebar: React.FC = () => {
    const urlGetCategories = `${EnvConfig.API_URL}api/categories/List`;

    const [categories, setCategories] = useState<ICategoryItem[]>([]);

    useEffect(() => {
        axios.get<IApiResponse<ICategoryItem[]>>(urlGetCategories)
            .then((res) => {
                console.log("Categories:", res.data);
                setCategories(res.data.payLoad);
            })
            .catch((err) => {
                console.error("Error loading categories:", err);
            });
    }, []);

    return (
        <aside className="w-1/4 bg-white p-4 rounded-lg shadow">
            <h2 className="text-lg font-semibold mb-4 text-black">
                Категорії
            </h2>
            <ul className="space-y-2">
                {categories.length > 0 ? (
                    categories.map((cat) => (
                        <li key={cat.id}>
                            <button
                                className="w-full text-left px-3 py-2 rounded-md text-sm font-medium text-gray-700 hover:bg-gray-200 transition"
                            >
                                {cat.name}
                            </button>
                        </li>
                    ))
                ) : (
                    <p className="text-sm text-gray-500">Категорії не знайдені</p>
                )}
            </ul>
        </aside>
    );
};

export default Sidebar;
