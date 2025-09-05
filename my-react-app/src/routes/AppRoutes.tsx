import {Route, Routes} from "react-router-dom";
import MainPage from "../pages/main/MainPage.tsx";
import * as React from "react";
import Login from "../pages/auth/Login.tsx";
import UsersList from "../pages/users/UsersList.tsx";
import MainLayout from "../layouts/MainLayout.tsx";
import NotFound from "../pages/NotFound.tsx";
import UserView from "../pages/users/UserView.tsx";
import CategoryList from "../pages/categories/CategoryList.tsx";
import CategoryView from "../pages/categories/CategoryView.tsx";

const AppRoutes: React.FC = () => {
    return (
        <Routes>
            <Route path="/" element={<MainLayout/>}>
                <Route index element={<MainPage/>} />
                <Route path={"/login"} element={<Login/>} />
                <Route path={"/usersList"} element={<UsersList/>} />
                <Route path={"/users"}>
                    <Route path={":id"} element={<UserView/>} />
                </Route>
                <Route path={"/category/List"} element={<CategoryList/>} />
                <Route path={"/category"}>
                    <Route path={":id"} element={<CategoryView/>} />
                </Route>
                <Route path="*" element={<NotFound />} />
            </Route>
        </Routes>
    )
}

export default AppRoutes;