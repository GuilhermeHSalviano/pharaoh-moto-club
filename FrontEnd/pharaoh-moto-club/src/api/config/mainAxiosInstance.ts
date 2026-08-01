import axios from 'axios'

const mainApiClient = axios.create({
    baseURL: `http://${window.location.hostname}:5000`,
})


export default mainApiClient;