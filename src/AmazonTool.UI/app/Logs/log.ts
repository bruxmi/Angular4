export interface ILog {
    Id: string;
    Message: string;
    TimeStamp: Date;
    Exception: string;
    Level: string;
    RequestId: string;
    UserName: string;
}

export interface ILogPaging {
    Count: number;
    PageIndex: number;
    PageSize: number;
    SearchTerm: string;
    IsDescending: boolean;
    Logs: ILog[];
}