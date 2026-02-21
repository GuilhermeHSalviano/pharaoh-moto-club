import { useContext, useEffect } from "react";
import { TokenContext } from "./TokenContext";
import { Outlet, useNavigate } from "react-router";

export function ProtectedRoutes() {
  const navigate = useNavigate();
  const tokenDoUsuario = useContext(TokenContext);

  useEffect(() => {
    if (!tokenDoUsuario || tokenDoUsuario == null) navigate("/");
  }, [tokenDoUsuario, navigate]);

  return <Outlet />;
}
