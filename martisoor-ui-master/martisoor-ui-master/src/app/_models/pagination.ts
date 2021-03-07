export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
}
export class PaginatedResult<T> {
    result: T[] = [];
    pagination: Pagination;
}

export class PagingOptions {
    page: number;
    size: number;
    filters: Filter[] = [];
}

export class Filter {
    name: string;
    value: string;

    // TODO: Operation field? Something like '==', '!=', '>', '<'
    // We may want to allow the client code to specify the comparison operator.
}
