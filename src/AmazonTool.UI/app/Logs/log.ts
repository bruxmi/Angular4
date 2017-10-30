export interface ILog {
    id: string;
    message: string;
    timeStamp: Date;
    exception: string;
    level: string;
    requestId: string;
    userName: string;
}

export interface ILogPaging {
    count: number;
    pageIndex: number;
    pageSize: number;
    searchTerm: string;
    isDescending: boolean;
    logs: ILog[];
}