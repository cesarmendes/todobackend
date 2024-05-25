//create a service rest api to object Task with axios

import { AxiosResponse } from "axios";
import Task from "../models/Task";
import ApiService from "./ApiService";
import Paginated from "../models/Paginated";

class TaskService extends ApiService {
    constructor() {
        super(import.meta.env.VITE_URL_BASE);
    }

    searchAsync(name:string, page: number) : Promise<AxiosResponse<Paginated<Task>>> {
        return super.getAsync<Paginated<Task>>(`v1/api/tasks?title=${name}&page=${page}`);
    }
    
    createAsync(task: Task) : Promise<AxiosResponse<Task>> {
        return super.postAsync<Task>(`v1/api/tasks`, task);
    }

    updateAsync(task: Task) : Promise<AxiosResponse<Task>> {
        return super.putAsync<Task>(`v1/api/tasks`, task);
    }

    removeAsync(id: number) : Promise<AxiosResponse<Task>> 
    {
        return super.deleteAsync<Task>('v1/api/tasks', {id: id, title: '', description: '', status: '', statusId: 0});
    }
}

export default TaskService;