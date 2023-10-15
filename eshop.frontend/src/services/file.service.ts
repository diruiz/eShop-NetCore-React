export const handleUpload = async (selectedFile : File) => {
	const formData = new FormData();
	formData.append(selectedFile.name, selectedFile);

	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/File`
	try {
		const response = await fetch(url, {
			method: 'POST',
			body: formData,
		});

		if (!response.ok) {
			throw new Error('Network response was not ok');
		}		
	} catch (error) {
		console.error('Error:', error);
	}
};