import { AxiosResponse } from "axios";
import Status from "../models/Status";
import ApiService from "./ApiService";

class StatusService extends ApiService {
    constructor() {
        super("https://localhost:7043");
    }

    searchAsync(name:string) : Promise<AxiosResponse<Status[]>> {
        return super.getAsync<Status[]>(`v1/api/status?title=${name}`);
    }
}

export default StatusService;