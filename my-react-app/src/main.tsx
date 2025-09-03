import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import {GoogleOAuthProvider} from "@react-oauth/google";
import {BrowserRouter} from "react-router-dom";

createRoot(document.getElementById('root')!).render(
  <GoogleOAuthProvider clientId={"1031539308106-5h7h65eh4s53dok7oma8eaj0hn2u2an4.apps.googleusercontent.com"}>
      <BrowserRouter>
          <App />
      </BrowserRouter>
  </GoogleOAuthProvider>,
)
