import React from "react";
import {Link} from "react-router-dom";
import {FaShoppingCart, FaSignInAlt, FaUser} from "react-icons/fa";

const Header : React.FC = () => {
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
                    <Link to="/usersList" className="text-gray-200 hover:text-white text-xl">
                        <FaUser/>
                    </Link>
                    <Link to="/login" className="text-gray-200 hover:text-white text-xl">
                        <FaSignInAlt/>
                    </Link>
                    <Link to="/cart" className="text-gray-200 hover:text-white text-xl">
                        <FaShoppingCart />
                    </Link>
                </nav>
            </div>
        </header>
    );
}

export default Header;