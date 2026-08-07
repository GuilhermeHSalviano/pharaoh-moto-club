import { useContext, useEffect } from "react";
import { ClaimsContext } from "./ClaimsContext";
import { Outlet, useNavigate } from "react-router";

export function ProtectedRoutes() {
  const navigate = useNavigate();
  const claimsDoUsuario = useContext(ClaimsContext);

  useEffect(() => {
    console.log(claimsDoUsuario)
    if (!claimsDoUsuario || claimsDoUsuario == null) navigate("/");
  }, [claimsDoUsuario, navigate]);

  return <Outlet />;
}
