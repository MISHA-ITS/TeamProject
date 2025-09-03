import {useGoogleLogin} from "@react-oauth/google";
import * as React from "react";

const Login : React.FC = () => {

    const loginByGoogle = useGoogleLogin({
        onSuccess: tokenResponse => {
            console.log("Get google token",tokenResponse)
        },
    });

    return (
        <div>
            <button
                style={{
                    padding: "5px 30px",
                    fontSize: "18px",
                    cursor: "pointer",
                    display: "flex",
                    alignItems: "center",
                    justifyContent: "center",
                    gap: "8px"
                }}
                onClick={() => loginByGoogle()}
            >
                Sign in with Google 🚀
            </button>
        </div>
    )
}

export default Login