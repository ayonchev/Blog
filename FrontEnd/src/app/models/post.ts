import { IComment } from "./comment";
import { ICategory } from "./category";
import { IUser } from "./user";

export interface IPost {
    postId: number;
    title: string;
    content: string;
    dateCreated: Date;
    comments: IComment[];
    category: ICategory;
    author: IUser;
}