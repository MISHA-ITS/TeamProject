import React from "react";
import { Link } from "react-router-dom";

const NotFound: React.FC = () => {
    return (
        <div className="flex flex-col items-center justify-center text-center px-4">
            <h1 className="text-2xl font-bold text-neutral-800">Помилка 404</h1>
            <p className="mt-4 text-lg text-neutral-600">
                Сторінку не знайдено
            </p>
            <p className="mt-4 text-sm text-neutral-600">
                Неправильно набрано адресу або такої сторінки на сайті більше не існує..
            </p>
            <Link
                to="/"
                className="mt-6 inline-block rounded-2xl bg-green-700 px-6 py-3 text-white font-medium shadow hover:bg-green-600 transition"
            >
                Перейти на головну сторінку
            </Link>
        </div>
    );
};

export default NotFound;