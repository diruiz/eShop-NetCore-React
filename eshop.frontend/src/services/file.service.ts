import { IFileUploadItem } from "../models/fileUpload.model";
import getFormDataHttpOptions from "./getFormDataHttpOptions";

export const handleUpload = async (selectedFile : File) => {
	const formData = new FormData();
	formData.append('file', selectedFile, selectedFile.name);

	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/File`
	try {
		const options = getFormDataHttpOptions(formData)
		const response = await fetch(url, options);

		if (!response.ok) {
			throw new Error('Network response was not ok');
		}
		const result = await response.json();
		return result as IFileUploadItem;
	} catch (error) {
		console.error('Error:', error);
	}
};