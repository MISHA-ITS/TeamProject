export interface IApiResponse<T> {
    isSuccess: boolean;
    message: string;
    payLoad: T;
}

export interface IUserItem {
    id: string;
    email: string;
    firstName: string | null;
    lastName: string | null;
    image: string | null;
    roles: string[];
}

export interface IUserRowProps {
    user: IUserItem;
    urlServer: string;
    initials: (name: string | null) => string;
}

export interface ICategory {
    id: string;
    name: string;
    description?: string;
}

export interface IProduct {
    id: string;
    name: string;
    description: string;
    price: number;
    image: string | null;
    categories: ICategory[];
}