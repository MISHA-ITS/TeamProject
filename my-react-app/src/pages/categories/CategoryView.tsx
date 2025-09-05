import {useParams} from "react-router-dom";

const CategoryView = () => {
    const { id } =  useParams<{id: string}>();
    return (
        <>
            <h1>Категорія {id}</h1>
        </>
    )
}

export default CategoryView;