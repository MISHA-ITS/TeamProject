import * as React from "react";
import { useGoogleLogin } from "@react-oauth/google";
import { AiFillGoogleCircle } from "react-icons/ai";

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
        onSuccess: (tokenResponse) => {
            console.log("Get google token", tokenResponse);
            // Тут можна додати логіку авторизації через Google токен
        },
        onError: () => {
            setState((prev) => ({ ...prev, error: "Google login failed" }));
        },
    });

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setState((prev) => ({ ...prev, [name]: value }));
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        setState((prev) => ({ ...prev, error: null }));

        if (!state.email || !state.password) {
            setState((prev) => ({ ...prev, error: "Будь ласка, заповніть всі поля" }));
            return;
        }

        // TODO: Виклик API для входу
        console.log("Email:", state.email);
        console.log("Password:", state.password);
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
