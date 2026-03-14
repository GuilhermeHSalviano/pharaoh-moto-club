import { BrowserRouter } from "react-router";
import { MyRoutes } from "./routes.tsx";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();
function App() {
  return (
    <>
      <BrowserRouter>
        <QueryClientProvider client={queryClient}>
          <MyRoutes></MyRoutes>
        </QueryClientProvider>
      </BrowserRouter>
    </>
  );
}

export default App;
