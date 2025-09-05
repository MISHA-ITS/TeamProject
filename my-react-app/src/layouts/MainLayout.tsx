import React from "react";
import { Outlet } from "react-router-dom";
import Sidebar from "../pages/components/Sidebar.tsx";
import Header from "../pages/components/Header.tsx";

const MainLayout: React.FC = () => {
    return (
        <div className="min-h-screen flex flex-col bg-white">
            {/* Header */}
            <Header/>

            {/* Main Content + Sidebar */}
            <div className="flex flex-1 max-w-7xl mx-auto w-full px-4 sm:px-6 lg:px-8 pt-20 pb-6 gap-6">
                {/* Sidebar (1/4 ширини) */}
                <Sidebar />

                {/* Основний контент (3/4 ширини) */}
                <main className="bg-white flex-1 p-6 rounded-lg shadow">
                    <Outlet />
                </main>
            </div>

            {/* Footer */}
            <footer className="bg-white border-t border-black/10">
                <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-4 text-sm text-gray-500 text-center">
                    © 2001–{new Date().getFullYear()} Інтернет-магазин «Розетка™» — Щоразу що треба
                    ТМ використовується на підставі ліцензії правовласника RozetkaLTD.
                </div>
            </footer>
        </div>
    );
};

export default MainLayout;
