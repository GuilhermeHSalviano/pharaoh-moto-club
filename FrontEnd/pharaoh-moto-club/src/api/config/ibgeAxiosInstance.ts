import axios from 'axios'

const ibgeApiClient = axios.create({
    baseURL: import.meta.env.VITE_IBGE_API_URL,
})


export default ibgeApiClient;