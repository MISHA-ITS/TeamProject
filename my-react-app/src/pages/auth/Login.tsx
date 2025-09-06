import * as React from "react";
import { useGoogleLogin } from "@react-oauth/google";
import { AiFillGoogleCircle } from "react-icons/ai";
import EnvConfig from "../../config/env.ts";

interface LoginState {
    email: string;
    password: string;
    error: string | null;
}

const Login: React.FC = () => {
    const [state, setState] = React.useState<LoginState>({
        email: "",
        password: "",
        error: null,
    });

    const loginByGoogle = useGoogleLogin({
        onSuccess: async (tokenResponse) => {
            console.log("Google tokenResponse:", tokenResponse);

            // 1. Витягуємо id_token
            const idToken = tokenResponse.access_token;
            if (!idToken) {
                setState((prev) => ({ ...prev, error: "Не отримано id_token від Google" }));
                return;
            }

            // 2. Відправляємо його на бекенд
            const googleDto = {
                IdToken: idToken
            };

            try {
                const response = await fetch(`${EnvConfig.API_URL}api/account/google-login`, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(googleDto),
                });

                const data = await response.json();
                if (!response.ok) {
                    setState((prev) => ({ ...prev, error: data.message || "Помилка входу через Google" }));
                    return;
                }

                localStorage.setItem("token", data.data);
                window.location.href = "/";
            } catch (error) {
                setState((prev) => ({ ...prev, error: "Помилка при надсиланні id_token на сервер" }));
            }
        },
        onError: () => {
            setState((prev) => ({ ...prev, error: "Google login failed" }));
        },
    });


    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setState((prev) => ({ ...prev, [name]: value }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setState((prev) => ({ ...prev, error: null }));

        if (!state.email || !state.password) {
            setState((prev) => ({ ...prev, error: "Будь ласка, заповніть всі поля" }));
            return;
        }

        try {
            const response = await fetch(`${EnvConfig.API_URL}api/account/login`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    email: state.email,
                    password: state.password,
                }),
            });

            const data = await response.json();

            if (!response.ok) {
                setState((prev) => ({ ...prev, error: data.message || "Помилка входу" }));
                return;
            }

            // Збереження токена (наприклад, localStorage)
            localStorage.setItem("token", data.data); // data.data - JWT токен

            // Перенаправлення після успішного входу
            window.location.href = "/"; // або використайте react-router navigate
        } catch (error) {
            setState((prev) => ({ ...prev, error: "Помилка мережі" }));
        }
    };


    return (
        <div className="max-w-md mx-auto mt-20 p-6 border border-gray-300 rounded-md shadow-sm">
            <h2 className="text-center text-2xl font-semibold mb-6">Вхід</h2>

            {state.error && (
                <div className="text-red-600 mb-4 text-center">{state.error}</div>
            )}

            <form onSubmit={handleSubmit} className="flex flex-col gap-4">
                <input
                    type="email"
                    name="email"
                    placeholder="Email"
                    value={state.email}
                    onChange={handleInputChange}
                    required
                    className="px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
                <input
                    type="password"
                    name="password"
                    placeholder="Пароль"
                    value={state.password}
                    onChange={handleInputChange}
                    required
                    className="px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
                <button
                    type="submit"
                    className="bg-white text-black font-medium py-2 rounded-md border border-gray-300 hover:bg-gray-100 transition"
                >
                    Продовжити
                </button>
            </form>

            <hr className="my-8 border-gray-300" />

            <button
                onClick={() => loginByGoogle()}
                className="w-full flex items-center justify-center gap-2 bg-white text-black font-medium py-2 rounded-md border border-gray-300 hover:bg-gray-100 transition"
            >
                <AiFillGoogleCircle /> Продовжити через Google
            </button>
        </div>
    );
};

export default Login;
