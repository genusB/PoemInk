const state = { generatedPoem: ''};

const getters = {
    generatedPoem: (poemState: any) => poemState.generatedPoem,
};

const mutations = {
    updateGeneratedPoem: (poemState: any, newPoem: string) => {
        poemState.generatedPoem = newPoem;
    },
    // emptyState() {
    //     this.VuexUndoRedo.replaceState({ generatedPoem: '' });
    // }
};

export default {
    state,
    getters,
    mutations,
};


