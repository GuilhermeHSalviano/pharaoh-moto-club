import axios from 'axios'

const mainApiClient = axios.create({
    baseURL: "https://aposporic-moony-azaria.ngrok-free.dev",
})


export default mainApiClient;