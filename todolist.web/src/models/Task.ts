interface Task {
    id: number;
    title: string;
    description: string;
    statusId: number;
    status?: string;
    startDate: Date;
    targetDate: Date;
}

export default Task;