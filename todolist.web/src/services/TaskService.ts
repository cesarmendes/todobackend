//create a service rest api to object Task with axios

import { AxiosResponse } from "axios";
import Task from "../models/Task";
import ApiService from "./ApiService";

class TaskService extends ApiService {
    constructor() {
        super("https://localhost:7043");
    }

    searchAsync(name:string) : Promise<AxiosResponse<Task[]>> {
        return super.getAsync<Task[]>(`v1/api/tasks?title=${name}`);
    }
    
    createAsync(task: Task) : Promise<AxiosResponse<Task>> {
        return super.postAsync<Task>(`v1/api/tasks`, task);
    }

    // async deleteAsync(id: number) : Promise<Task> 
    // {
    //     return super.deleteAsync<Task>('v1/api/tasks', {id: id, title: '', description: '', status: ''});
    // }
}

export default TaskService;