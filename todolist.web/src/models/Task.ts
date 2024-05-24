interface Task {
    id: number;
    title: string;
    description: string;
    statusId: number;
    status?: string
}

export default Task;