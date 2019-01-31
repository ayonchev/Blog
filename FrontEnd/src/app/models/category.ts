import { IPost } from "./post";

export interface ICategory {
    categoryId: number;
    name: string;
    posts: IPost[];
}