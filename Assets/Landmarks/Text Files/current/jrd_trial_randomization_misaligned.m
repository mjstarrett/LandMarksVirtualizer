%% Script to randomize misaligned trials for JRD task from list.txt in Landmarks

% NOTE: To make your life easier, just re-save the list as a .xlxs file format

%cd('/Users/mjstarrett/repos/LandMarksOculus/Assets/Landmarks/Text Files/current/');

% From the Home tab:
%     - Select 'Import Data'
%     - Choose 'list_bigCityCyberith.xlsx'
%     - Choose 'Cell Array' format for the imported data
%     - Select ALL
%     - Import

rng shuffle; % set the random number generator to the current time (otherwise produces same list each time)

noSpace = listbigCityCyberithALL(1:2:end); %remove the blank spaces between Questions
aligned = noSpace(1:84); %separate Aligned trials
misaligned = noSpace(85:end); %separate Misaligned trials
p = randperm(length(misaligned)); %create a randomization index
misaligned_rand = misaligned(p); %new variable with misaligned trials randomized according to p index (see line above)
misaligned_rand_final = misaligned_rand(1:84); %Take just the first 84 randomized trials (equal to # of aligned trials) 
final_combined = [aligned; misaligned_rand_final];
save('list_bigCityCyberith_final.txt','final_combined') % save it as a text file

% You will have to go press enter on each line to get it back into the same
% format as the original (or just leave it without line spaces; they really
% just make it look pretty and add extra lines of code to work with (see
% above).





