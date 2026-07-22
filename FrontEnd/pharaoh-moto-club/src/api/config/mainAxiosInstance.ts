import axios from 'axios'

const mainApiClient = axios.create({
    baseURL: "https://aposporic-moony-azaria.ngrok-free.dev",
    headers: {
    "ngrok-skip-browser-warning": "true",
  },
})


export default mainApiClient;