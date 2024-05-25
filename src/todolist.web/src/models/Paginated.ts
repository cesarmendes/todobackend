interface Paginated<T> {
    totalPages: number;
    totalItems: number;
    pageNumber: number;
    pageSize: number;
    hasPreviousPage: boolean;
    hasNextPage: boolean;
    isFirstPage: boolean;
    isLastPage: boolean;
    items: T[];
}

export default Paginated;
