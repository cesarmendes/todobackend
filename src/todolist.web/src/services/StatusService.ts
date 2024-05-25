import { AxiosResponse } from "axios";
import Status from "../models/Status";
import ApiService from "./ApiService";
import Paginated from "../models/Paginated";

class StatusService extends ApiService {
    constructor() {
        super(import.meta.env.VITE_URL_BASE);
    }

    searchAsync(name:string) : Promise<AxiosResponse<Paginated<Status>>> {
        return super.getAsync<Paginated<Status>>(`v1/api/status?title=${name}`);
    }
}

export default StatusService;