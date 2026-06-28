import axios from 'axios'

const apiClient = axios.create({
    baseURL: import.meta.env.VITE_API_URL,
     headers: {
    "ngrok-skip-browser-warning": "1",
  }
})


export default apiClient;