import axios, {AxiosResponse} from  'axios';

class ApiService{
    private baseUrl: string
    private headers =  {
        'Content-Type': 'application/json',
    }

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    getAsync<T>(path: string): Promise<AxiosResponse<T>> {
        const url = `${this.baseUrl}/${path}`;
        return axios.get<T>(url, {headers: this.headers});
    }

    postAsync<T>(path: string, data: T): Promise<AxiosResponse<T>> {
        const url = `${this.baseUrl}/${path}`;
        return axios.post<T>(url, data, {headers: this.headers});
    }

    putAsync<T>(path: string, data: T): Promise<AxiosResponse<T>> {
        const url = `${this.baseUrl}/${path}`;
        return axios.post<T>(url, data, {headers: this.headers});
    }
    deleteAsync<T>(path: string, data: T): Promise<AxiosResponse<T>> {
        const url = `${this.baseUrl}/${path}`;
        return axios.post<T>(url, data, {headers: this.headers});
    }
}

export default ApiService;
