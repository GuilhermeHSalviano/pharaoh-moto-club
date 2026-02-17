import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    allowedHosts: [
      "your-domain.com",
      "unrubricated-adele-travelled.ngrok-free.dev",
    ],
  },
});
