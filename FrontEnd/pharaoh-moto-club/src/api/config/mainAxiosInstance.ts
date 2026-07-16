import axios from 'axios'

const mainApiClient = axios.create({
    baseURL: import.meta.env.VITE_MAIN_API_URL,
})


export default mainApiClient;