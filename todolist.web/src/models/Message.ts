interface Message {
    open: boolean;
    value: string;
    severity: "success" | "error";
}

export default Message;