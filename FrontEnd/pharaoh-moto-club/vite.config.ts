import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import { VitePWA } from "vite-plugin-pwa";

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    react(),
    VitePWA({
      registerType: "autoUpdate",
      includeAssets: ["favicon.ico", "robots.txt", "apple-touch-icon.png"],
      manifest: {
        short_name: "Faraós - MC",
        name: "Faraós Moto Clube",
        start_url: "/",
        display: "standalone",
        background_color: "#000000",
        theme_color: "#000000",
        icons: [
          {
            src: "/public/seven-192.png",
            sizes: "192x192",
            type: "image/png",
          },
          {
            src: "/public/seven-512.png",
            sizes: "512x512",
            type: "image/png",
          },
        ],
      },
      devOptions: {
        enabled: true,
        type: "module",
        navigateFallback: "index.html",
      },
    }),
  ],
  server: {
    allowedHosts: [
      "your-domain.com",
      "unrubricated-adele-travelled.ngrok-free.dev",
    ],
  },
});
