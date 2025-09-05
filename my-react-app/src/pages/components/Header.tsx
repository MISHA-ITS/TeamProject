import React, { useState, useEffect } from "react";
import { BiCategory } from "react-icons/bi";
import { Link, useNavigate } from "react-router-dom";
import { FaShoppingCart, FaSignInAlt, FaUser , FaSignOutAlt } from "react-icons/fa";

const Header: React.FC = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        const token = localStorage.getItem("token");
        setIsLoggedIn(!!token);
    }, []);

    const handleLogout = () => {
        localStorage.removeItem("token");
        setIsLoggedIn(false);
        navigate("/login"); // перенаправлення на сторінку входу
    };

    return (
        <header className="fixed top-0 left-0 right-0 z-50 bg-black shadow-sm border-b border-black/20">
            <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex items-center justify-between h-16">

                {/* Лівий блок - логотип */}
                <Link to="/" className="flex items-center gap-2">
                    <img
                        src="https://content.rozetka.com.ua/logo/site_dark_theme/original/581747881.svg"
                        alt="Logo"
                        className="h-10 w-auto"
                    />
                </Link>

                <nav className="flex items-center gap-4">
                    <Link to="/category/List" className="text-gray-200 hover:text-white text-xl">
                        <BiCategory />
                    </Link>
                    <Link to="/usersList" className="text-gray-200 hover:text-white text-xl">
                        <FaUser  />
                    </Link>

                    {isLoggedIn ? (
                        <button
                            onClick={handleLogout}
                            className="text-gray-200 hover:text-white text-xl flex items-center gap-1 bg-transparent border-none cursor-pointer"
                            aria-label="Logout"
                        >
                            <FaSignOutAlt /> Вийти
                        </button>
                    ) : (
                        <Link to="/login" className="text-gray-200 hover:text-white text-xl">
                            <FaSignInAlt />
                        </Link>
                    )}

                    <Link to="/cart" className="text-gray-200 hover:text-white text-xl">
                        <FaShoppingCart />
                    </Link>
                </nav>
            </div>
        </header>
    );
};

export default Header;