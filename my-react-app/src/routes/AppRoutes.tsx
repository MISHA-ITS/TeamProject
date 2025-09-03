import {Route, Routes} from "react-router-dom";
import MainPage from "../pages/main/MainPage.tsx";
import * as React from "react";
import Login from "../pages/auth/Login.tsx";
import UsersList from "../pages/users/UsersList.tsx";

const AppRoutes: React.FC = () => {
    return (
        <Routes>
            <Route path="/">
                <Route index element={<MainPage/>} />
                <Route path={"/login"} element={<Login/>} />
                <Route path={"/usersList"} element={<UsersList/>} />
            </Route>
        </Routes>
    )
}

export default AppRoutes;