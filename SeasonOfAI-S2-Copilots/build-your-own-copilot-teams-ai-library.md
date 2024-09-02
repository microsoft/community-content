# Build your own copilot using Teams AI library and .NET

>**Pre-requisites**
>- Microsoft 365 account
>- Teams Toolkit for Visual Studio installed
>- Azure OpenAI resource and `gpt-35-turbo` and `text-embedding-ada-002` deployed
>- Azure Storage Account and Azure AI Search resources

In Visual Studio, select **Create a new project > Microsoft Teams app**. Enter “Career-Genie” as the name of your app, then select Next. Select **AI Chat Bot** as the template and then **Create**.

When the app is scaffolded, quickly walk through the solution folders. Open `env.local.user` and copy your Azure OpenAI endpoint and key.

Select the arrow on the right side of the Start button and select **Dev Tunnels > Create a Tunnel**. Select the account you want to test this app, enter a name for your tunnel, select "Temporary" as tunnel type and select "Public" as access type, then select **OK**.

Right-click to the TeamsApp folder and select **Teams Toolkit > Prepare Teams App Dependencies**, select the account you want to test your app and then **Continue**.

Once the app is prepared, select Start or **F5** to debug your app on Teams. When Teams pops up on your browser and shows your app, select **Add** and start testing your app.

Start your conversation with “Hi” and then ask questions similar to “can you suggest candidates who are expert in python?” and recognize that the Career Genie is responding with generic methods, suggesting Upwork, Freelancer websites.

Now, let’s add some data and prompt to customize Career Genie.

Download [fictitious_resumes.zip](./../assets/fictitious_resumes.zip) and unzip the folder.

Open Azure OpenAI Studio in your browser, then select **Chat** playground. In the Setup section, select **Add** your data tab and then Add a data source.

Select Upload files (preview), then fill the details as the following and select Next. Select the subscription you created your Azure resources. Select your storage resource and Azure AI Search resource, enter an index name, such as "resumes". Select the box for Add vector search to this search resource. Select your `text-embedding-ada-002` model, "text-embeddings". Select Browse for a file and select the pdf documents from the fictitious_resumes folder. Then, select Upload files and Next. Select Search type as Vector and chunk size as 1024(Default), then Next. Select API Key as Azure resource authentication type, then Next. Once your data ingestion is completed, use Chat playground to ask questions about your data.

Now, go back to your app, open `prompts > chat > skprompt.txt` and paste the below system prompt:

```
You are a career specialist named "Career Genie" that helps Human Resources team for writing job posts.
You are friendly and professional.
You always greet users with excitement and introduce yourself first.
You like using emojis where appropriate.
```

Open `prompts > chat > config.json`, replace it with the following snippet and copy your Azure AI Search key, endpoint and Azure OpenAI text embedding model name in the related fields:

```
{
  "schema": 1.1,
  "description": "A bot that can chat with users",
  "type": "completion",
  "completion": {
    "completion_type": "chat",
    "include_history": true,
    "include_input": true,
    "max_input_tokens": 2800,
    "max_tokens": 1000,
    "temperature": 0.9,
    "top_p": 0.0,
    "presence_penalty": 0.6,
    "frequency_penalty": 0.0,
    "data_sources": [
      {
          "type": "azure_search",
          "parameters": {
              "endpoint": “YOUR-AI-SEARCH-ENDPOINT”,
              "index_name": "$indexName",
              "authentication": {
                  "type": "api_key",
                  "key": “YOUR-AI-SEARCH-KEY”
              },
              "query_type":"vector",
              "in_scope": true,
              "strictness": 3,
              "top_n_documents": 3,
              "embedding_dependency": {
                "type": "deployment_name",
                "deployment_name": “YOUR-EMBEDDING-MODEL-NAME”
              }
          }
      }
    ]
  }
}
```

Now go back to Teams and ask similar questions to Career Genie. Recognize the change in its behavior, and it uses emojis as it was defined in the system prompt.

Also recognize when you ask any developer suggestions for the open positions, instead of guiding you to career websites, it actually brings resumes from Azure AI Search as suggestions.

Continue asking more suggestions with different qualifications such as years of experience, different programming language experience, location of the candidate to explore more about your data. 