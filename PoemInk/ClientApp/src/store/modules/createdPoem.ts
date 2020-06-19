const state = { createdPoem: ''};

const getters = {
    createdPoem: (poemState: any) => poemState.createdPoem,
};

const mutations = {
    updateCreatedPoem: (poemState: any, newPoem: string) => {
        poemState.createdPoem = newPoem;
    },
};

export default {
    state,
    getters,
    mutations,
};


