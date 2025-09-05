// services/userService.ts
import { IUserItem } from '../types';

const API_URL = 'http://localhost:5137/api/user';

export const userService = {
    // Отримати всіх користувачів
    getAll: async (): Promise<IUserItem[]> => {
        const response = await fetch(`${API_URL}/List`);
        if (!response.ok) throw new Error('Помилка завантаження користувачів');
        return response.json();
    },

    // Видалити користувача (ID в тілі запиту)
    delete: async (id: string): Promise<void> => {
        const response = await fetch(API_URL, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ id }), // ID передається в тілі
        });
        if (!response.ok) throw new Error('Помилка видалення користувача');
    },

    // Оновити користувача (ID в тілі запиту)
    update: async (user: IUserItem): Promise<IUserItem> => {
        const response = await fetch(API_URL, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user), // Весь об'єкт в тілі
        });
        if (!response.ok) throw new Error('Помилка оновлення користувача');
        return response.json();
    },

    // Створити користувача
    create: async (user: Omit<IUserItem, 'id'>): Promise<IUserItem> => {
        const response = await fetch(API_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user),
        });
        if (!response.ok) throw new Error('Помилка створення користувача');
        return response.json();
    },
};