# Build your own copilot using Teams AI library and .NET

These instructions are designed for community leaders and presenters who wish to pick up this session on Build your own copilot using Teams AI library and .NET at community events. Below, you’ll find all the necessary assets and relevant instructions for each stage of the presentation.

This demos for this session currently use Visual Studio 2022 and Teams Toolkit.

## Session Details

**Session Title:** Build your own copilot using Teams AI library and .NET

**Session Abstract:** Unlock the potential of your .NET apps by crafting a custom copilot using Teams AI library, Teams Toolkit, and Azure OpenAI. In this session, you will learn how to integrate advanced AI capabilities with .NET, enhancing productivity and collaboration within Microsoft Teams. We'll explore how to leverage the Teams AI library for intelligent features, utilize the Teams Toolkit for streamlined development, and harness the power of Azure OpenAI to bring in Generative AI models. Join us to gain practical insights and skills to create impactful, AI-powered custom copilots tailored to your organization’s needs.

**Level:** 200

**Goal of the session:** Provide an overview of how Teams Toolkit works and how to build your own copilot using Teams Toolkit for Visual Studio, Teams AI library and .NET.

**Duration:** 45 Minutes + Q&A Time

**Speaker Expectation/Skills:** Mid level theory content, a demo with instructions

## Assets you will need to redeliver this session
* Download the PowerPoint Presentation for talk [here](./build.your.own.copilot.with.teams.ai.library.pptx).
* Follow the demo instructions below.

## Demo instructions
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
  "data_sources": [
    {
      "type": "azure_search",
      "parameters": {
        "endpoint": "'$search_endpoint'",
        "semantic_configuration": "default",
        "query_type": "vector",
        "fields_mapping": {},
        "in_scope": true,
        "role_information": "You are a career specialist named \"Career Genie\" that helps Human Resources team for writing job posts.\nYou are friendly and professional.\nYou always greet users with excitement and introduce yourself first.\nYou like using emojis where appropriate.",
        "filter": null,
        "strictness": 3,
        "top_n_documents": 5,
        "authentication": {
          "type": "api_key",
          "key": "'$search_key'"
        },
        "embedding_dependency": {
          "type": "deployment_name",
          "deployment_name": "text-embedding-ada-002"
        },
        "key": "'$search_key'",
        "indexName": "'$search_index'"
      }
    }
  ],
  "messages": [
    {
      "role": "system",
      "content": "You are a career specialist named \"Career Genie\" that helps Human Resources team for writing job posts.\nYou are friendly and professional.\nYou always greet users with excitement and introduce yourself first.\nYou like using emojis where appropriate."
    }
  ],
  "temperature": 0.7,
  "top_p": 0.95,
  "max_tokens": 800,
  "stop": null,
  "stream": true,
  "past_messages": 10,
  "frequency_penalty": 0,
  "presence_penalty": 0,
  "azureSearchEndpoint": "<YOUR-AI-SEARCH-ENDPOINT>",
  "azureSearchKey": "<YOUR-AI-SEARCH-API-KEY>",
  "azureSearchIndexName": "<YOUR-AI-SEARCH-INDEX-NAME>"
}

```

Now go back to Teams and ask similar questions to Career Genie. Recognize the change in its behavior, and it uses emojis as it was defined in the system prompt.

Also recognize when you ask any developer suggestions for the open positions, instead of guiding you to career websites, it actually brings resumes from Azure AI Search as suggestions.

Continue asking more suggestions with different qualifications such as years of experience, different programming language experience, location of the candidate to explore more about your data. 
