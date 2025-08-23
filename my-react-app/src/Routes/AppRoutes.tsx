import {Route, Routes} from "react-router-dom";
import UsersList from "../Pages/Users/UsersList.tsx";
import UserView from "../Pages/User/UserView.tsx";
import NotFound from "../Pages/NotFounf.tsx";
import Login from "../Pages/Auth/Login.tsx";
import * as React from "react";
import MainLayout from "../layOuts/MainLayout.tsx";


const AppRoutes: React.FC = () => {
    return (
        <Routes>
            <Route path="/" element={<MainLayout />}>
                <Route index element={<UsersList />} />
                <Route path={"login"} element={<Login />} />
                <Route path={"user"}>
                    <Route path={":id"} element={<UserView />} />
                </Route>
            </Route>
            <Route path="*" element={<NotFound />} /> {/* 👈 */}
        </Routes>
    )
}
export default AppRoutes;