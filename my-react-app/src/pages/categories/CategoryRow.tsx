import type {ICategoryRowProps} from "../types.ts";
import * as React from "react";
import {Link} from "react-router-dom";
import { FaPen, FaTrash  } from "react-icons/fa";

const CategoryRow : React.FC<ICategoryRowProps> = ({ category }) => {
    return (
        <>
            <Link to={`/category/${category.id}`}>
                <li className="m-3 p-1 border rounded-lg shadow-lg flex items-center w-full gap-4">
                    <div className="flex-grow">
                        <h3 className="font-semibold">{category.name}</h3>
                        {category.description && (
                            <p className="text-gray-600">{category.description}</p>
                        )}
                    </div>
                    <div className="flex gap-2 ml-auto">
                        <button className="px-3 py-1 bg-green-500 text-white rounded hover:bg-green-700 transition-colors flex items-center gap-1" onClick={() => alert(`Edit category ${category.id}`)}>
                            Редагувати <FaPen />
                        </button>
                        <button className="px-3 py-1 bg-red-500 text-white rounded hover:bg-red-700 transition-colors flex items-center gap-1" onClick={() => alert(`Delete category ${category.id}`)}>
                            Видалити <FaTrash />
                        </button>
                    </div>
                </li>
            </Link>
        </>
    )
}

export default CategoryRow;