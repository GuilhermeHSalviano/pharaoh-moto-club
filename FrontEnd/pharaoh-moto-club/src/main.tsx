import { StrictMode } from "react";
import { createRoot } from "react-dom/client";

import { MyGlobalStyle } from "./components/GlobalStyle.tsx";
import App from "./App.tsx";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <MyGlobalStyle></MyGlobalStyle>
    <App></App>
  </StrictMode>,
);
