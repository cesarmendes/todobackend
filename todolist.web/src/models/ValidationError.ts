interface ValidationError{
    title: string,
    status: number,
    errors: {[key: string]: string[]};
}

export default ValidationError;