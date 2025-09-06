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
    initials: (name: string | null) => string;
}

export interface ICategoryItem {
    id: string;
    name: string;
    description?: string;
    image?: string;
}

export interface IProductItem {
    id: string;
    name: string;
    description: string;
    price: number;
    image: string | null;
    categories: ICategoryItem[];
}

export interface ApiResponse<T = any> {
  data: T;
  message?: string;
  isSuccess: boolean;
  errors?: string[];
}

export interface Product {
  id: string;
  name: string;
  description?: string;
  price: number;
  stockQuantity: number;
  imageUrl?: string;
  categoryId: string;
  category?: Category;
  createdDate?: string;
  updatedDate?: string;
}