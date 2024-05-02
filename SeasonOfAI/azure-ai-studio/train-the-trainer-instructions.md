# Getting started with Azure AI Studio

These instructions are designed for community leaders and presenters who wish to pick up this Azure AI Studio session and re-deliver it at community events. Below, you’ll find all the necessary assets and relevant instructions for each stage of the presentation.

## Session Details

**Session Title:** Getting started with Azure AI Studio

**Session Abstract:** Dive into Azure AI Studio - a cutting-edge 'code first' experience for building generative AI copilots. You will start by touring the studio experience, moving on to creating a RAG model, exploring other multi-modal models and wrapping up with the importance of evaluations and deployments. Join us and harness the power of Azure AI Studio to transform your ideas into reality!

**Level:** 200

**Goal of the session:** Introduce the audience to Azure AI Studio and its capabilities.

**Duration:** 45 mins session content, 60 mins with time for Q&A

**Speaker Expectation/Skills:** mid level theory content, multiple complex demos

## Assets you will need to redeliver this session

* Watch the recording of Ignite 2023 session ['Build your own Copilot with Azure AI Studio'](https://ignite.microsoft.com/sessions/a630f4eb-a148-43cd-8a36-38dec7ed7098?source=sessions) to learn the basics of Azure AI Studio.
* Powerpoint Presentation available in zip download [here]("https://github.com/microsoft/community-content/releases/download/SeasonOfAI/Getting.Started.with.Azure.AI.Studio.May2024.zip")
* Demo videos are also available unlisted on YouTub, in a [YouTube Playlist](https://www.youtube.com/playlist?list=PL-049HD1kG2g6CC3R8Q5wv2EUdGCqQWLV) and included in the [.zip file](https://github.com/microsoft/community-content/releases/download/SeasonOfAI/Getting.Started.with.Azure.AI.Studio.May2024.zip), they include:
    1. [Demo 1 - Tour of the Studio](https://studio.youtube.com/video/I9ekiqMyiSI/edit)
    2. [Demo 2 - Add your own data to your copilot](https://youtu.be/slJzhRu1I3I)
    3. [Demo 3 Part 1 - Models-as-a-Service (MaaS) and fine-tuning](https://youtu.be/5-lnzrHyYow)
    4. [Demo 3 Part 2 - Multi-modality](https://youtu.be/UnATh9TsM3o)
    5. [Demo 4 - Evaluations and Deployments](https://youtu.be/j73U-mppwWw)

> Note: Videos are not currently added into the deck, as part of the lerning journey please include them in the assigned sections

For ease of delivery we have provided video demos which we recommend speaking over for the maximum impact and delivery of message.

## Demo Breakdown

Find below some step-by-step details to support you learning the pace and steps the demos include:

### Demo 1 - Tour the studio

**Goal: Give a quick overview of studio**

* Show projects
* Show settings (Azure AI Resource / Connections / Compute Instances / Runtimes / User Management)
* Show Deployments
* Show Chat Playground and Prompt: How much do the TrailWalker hiking shoes cost?
* Show Chat Playground and Add your own data with index: contoso-outdoor-products-index
* Prompt: How much do the TrailWalker hiking shoes cost? and show the outcome providing the reference to the item in the index
* Translate prompt to Greek, Prompt: Πόσο κοστίζουν τα παπούτσια πεζοπορίας TrailWalker; and see response also returned in Greek including reference link
* Show Chat Playground and update System message
    * You are an AI assistant, You always response in a rhyme. You are friendly and funny
* Prompt: What can you tell me about San Francisco?
* Show Chat Playground and manual evaluation options
* Enter one manual (How much do the TrailWalker hiking shoes cost?)
* Show how to import more test data using the dataset: contoso-outdoor-evaluation
* Run All and review results

[![Demo 1 - Tour the studio](https://img.youtube.com/vi/I9ekiqMyiSI/0.jpg)](https://www.youtube.com/watch?v=I9ekiqMyiSI)

### Demo 2 - Add your own data

**Goal: Show the ease and power of adding your own data to the conversation**

* Add data (dataset: contoso-outdoor-products-and-climate)
* Create Index (index: contoso-outdoor-products-and-climate-index)
* "Add your own data" in the playground environment
* Hybrid Search
* Use model: gpt-4-turbo
* Ask question "What products are suitable for the San Francisco climate?" - call out references to data provided

[![Demo 2 - Add your own data](https://img.youtube.com/vi/slJzhRu1I3I/0.jpg)](https://www.youtube.com/watch?v=slJzhRu1I3I)

### Demo 3 Part 1 - Models-as-a-Service (MaaS) and fine-tuning

**Goal: Show the ease of customization and diversity of models**

* Show Model Benchmarking
* Deploy Llama 2.7b text  as Pay As You Go
* Fine-tune Llama 2.7b text - providing training and validation datasets
* Deploy Fine-tuned model as Pay As You Go, open in playground and test

[![Demo 3 Part 1 - Models-as-a-Service and fine-tuning](https://img.youtube.com/vi/5-lnzrHyYow/0.jpg)](https://www.youtube.com/watch?v=5-lnzrHyYow)

### Demo 3 Part 2 - Multi-modality

**Goal: Show the power of multi-modality**

* Generate images with Dall-e 3
* Use speech to text in playground to ask a question
* Multi Vision (Create half day itinerary based on photo)
* Use AI Vision service enhancements toggle to extract what is in the image.

[![Demo 3 Part 2 - Multi-modality](https://img.youtube.com/vi/UnATh9TsM3o/0.jpg)](https://www.youtube.com/watch?v=UnATh9TsM3o)

### Demo 4 - Evaluations and Deployments

**Goal: The ability to evaluate and test before going to production and easy deployment and production monitoring**

Prompt Flow:
* Show the "Contoso Outdoor RAG" prompt flow

Evaluate:
* Show Built-in Evaluation wizard with question and answer pairs
* Show output of evaluation metrics: Groundedness, Relevance and Coherence

Deploy:
* Show deployment wizard steps
* Show deployed flow and test
* Show monitoring you can enable for your production model based on evaluation metrics monitoring over time
* Gradually switch traffic from one model deployment to another as engineering best practice.

[![Demo 4 - Evaluations and Deployment](https://img.youtube.com/vi/j73U-mppwWw/0.jpg)](https://www.youtube.com/watch?v=j73U-mppwWw)