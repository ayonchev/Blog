import { IUser } from "./user";

export interface IComment {
    commentId: number;
    content: string;
    dateCreated: Date;
    author: IUser;
    anonymousAuthorEmail: string;
}